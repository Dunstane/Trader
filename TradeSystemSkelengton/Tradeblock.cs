using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSystemSkelengton
{
    /// <summary>
    /// tradeblock that contains a resource_ quantity of that resource
    /// moves up and down a tradeline.
    /// </summary>
    internal class Tradeblock
    {
        private double location;
        private double distance;
        private bool arrived=false;
        private int speed;
        private string resource;
        private int quantity;
        /// <summary>
        /// Tradeblock that moves up and down a tradeline, has a number of 
        /// </summary>
        /// <param name="distance">last tick of tradeline/ or just the distance</param>
        /// <param name="speed">speed it moves up and down a tradeline</param>
        /// <param name="resource_quantity">How much</param>
        /// <param name="resource">what am I transporting</param>
        
        public Tradeblock(double distance,int speed, int resource_quantity, string resource)
        {
            if (distance>0 && speed<1 && speed>10 && resource_quantity>=1 && TradeSystem.acceptedResourceNames.Contains(resource))
            {
                this.distance = distance;
                this.speed = speed;
                this.resource = resource;
                this.quantity = resource_quantity;
            }
            else
            {

                Debug.WriteLine("Something went wrong in tradeblock initialization");
                //raise error
            }



        }


        /// <summary>
        /// moves itself
        /// currently will not be smooth, 
        /// todo, design a system that does these transitons more smoothly, for ex. 95+7=102
        /// </summary>
        public void move()
        {
            if (arrived != true)
            {
                if (this.location >= distance) //redundant? possibly, may keep it in for fault def location settings
                {
                    Arrived();
                }
                else
                {
                    this.location += speed;

                    if (this.location >= distance)
                    {
                        Arrived();
                    }
                }
            }
        }

        /// <summary>
        /// gives the name of the resource in the block
        /// </summary>
        /// <returns></returns>
        public string giveTransportName()
        {
            return this.resource;
        }
        public int giveTransportQuantity()
        {
            return this.quantity;
        }

        /// <summary>
        /// just a simple value changer
        /// </summary>
        private void Arrived()
        {
            arrived = true;
        }
        /// <summary>
        /// reports arrival status to whatever asks
        /// </summary>
        /// <returns></returns>
        public bool arriveReport()
        {
            return arrived;
        }
    }
}
