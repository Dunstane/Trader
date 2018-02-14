using System;
using System.Collections.Generic;

namespace TradeSystemSkelengton
{
    /// <summary>
    /// trade lines between cities, in which tradeblocks are sent which has resources
    /// </summary>
    internal class TradeLine
    {
        double distance;   //distance between both cities
        bool direction; //0=regular, 1= switched
        private List<Tradeblock> blocks;    //a block that enters the tradeline and ticks towards the end of it, not sure if needs to lock own location, or if a LL is sufficient. Attached is a resource+quantity
        
        private City StartCity;     //end and start cities
        private City EndCity;
        private int roadspeed;  //upgradable road speed

        //city 1 and city 2 indicates direction
        //->
        //switch them around <-
        public TradeLine(City a, City b, bool direction)
        {
            if (a != null && b != null)
            {
                //get location from cities, could be that the cities are all on dependant roads, or not. for test should just be locations
                if (direction != false)
                {
                    StartCity = a;
                    EndCity = b;


                }
                else
                {
                    StartCity = b;
                    EndCity = a;
                }
                double deltaX = Math.Pow((b.givexLoc() - a.givexLoc()), 2);
                double deltaY = Math.Pow((b.giveyLoc() - a.giveyLoc()), 2);
                distance = Math.Sqrt(deltaY + deltaX);
                blocks = new List<Tradeblock>();
            }
        }

        public void addTradeBlock(string resource,int quantity)
        {
          

            Tradeblock temp = new Tradeblock(this.distance, this.roadspeed, quantity, resource);
            blocks.Add(temp);
        }


        public void consumeTB(Tradeblock datFukkenBlock)
        {
            if (this.EndCity.containsResource(datFukkenBlock.giveTransportName()))
            {
                this.EndCity.addToResource(datFukkenBlock.giveTransportName(), datFukkenBlock.giveTransportQuantity());
            }
            else
            {
                 Resource temp = new Resource(datFukkenBlock.giveTransportName(),datFukkenBlock.giveTransportQuantity(),EndCity);
                
            }

        }

        /// <summary>
        /// does a tick that moves all the blocks
        /// </summary>
        public void tick()
        {
            foreach (Tradeblock x in blocks)
            {
                if (x.arriveReport() != true)
                {
                    x.move();
                }
                else
                {

                    //block arrived, change values, delete from list
                    EndCity.addToResource(x.giveTransportName(), x.giveTransportQuantity());
                    blocks.Remove(x);
                }
              
            }
        }
    }
}