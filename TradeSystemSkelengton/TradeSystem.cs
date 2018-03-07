using System.Collections.Generic;
using System.Diagnostics;

namespace TradeSystemSkelengton
{
    //TODO after 2nd stretch
    //rethinking of the resource system
    //city consumption and production
    //city types
    //pulse system.

 

    /// <summary>
    /// System to be used in trade game. mainly aims to trade resources between nodes(cities)
    /// </summary>
    internal class TradeSystem
    {
        private List<TradeLine> TradeLines; //list of tradelines
        private List<City> Cities; //list of known cities to system      todo needs identifiers
        private List<Resource> Resources;
        public static List<string> acceptedResourceNames;
    

        /// <summary>
        /// initialize system with default values if needed
        /// </summary>
        public TradeSystem()
        {
            TradeLines = new List<TradeLine>();
            Cities = new List<City>();
            acceptedResourceNames = new List<string>();
            acceptedResourceNames.Add("Corn");   //can be consumed for food
            acceptedResourceNames.Add("RawGold"); //can be processed into currency per tick
            acceptedResourceNames.Add("Currency"); //can be used to buy resources
            acceptedResourceNames.Add("Wood"); //can be sold/consumed for upgraded along with gold
            acceptedResourceNames.Add("Spices"); //generic luxary good, think civ 5
            acceptedResourceNames.Add("Iron"); //tier 2 upgrades

            City temp = new City("Cascadia", 0f, 9f);                               //may need to check on the actual number
            Cities.Add(temp);

        }

        //add city to system with all of it's properties
        public void addCity()
        {
            City temp = new City("Meme",  5f, 9f );                               //may need to check on the actual number
            Cities.Add(temp);
        }

        /// <summary>
        /// Here is where I want to do the initial trade connection. with the resources that are being traded
        /// maybe in tradeline I distiguish the different lines of resource trade?
        /// </summary>
        public void addTradeline(int cityID1, int cityID2)
        {
            City tempc1 = null;
            City tempc2 = null;
            //both cities found, then assign
            if (this.Cities[cityID1] != null)
            {
                tempc1 = this.Cities[cityID1];

                if (this.Cities[cityID2] != null)
                {
                    tempc2 = this.Cities[cityID2];

                    //at this point if both aren't null, then may as well continue
                    TradeLine temp = new TradeLine(tempc1, tempc2,true);
                }
                else
                {
                    Debug.WriteLine("City 2 is invalid");
                }
            }
            else
            {
                Debug.WriteLine("City 1 is invalid");
            }
        }


        /// <summary>
        /// finds city, returns position
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int returnCityIndex(string name)
        {
            int index = 0;      //simple index so we dont need to call this.cities
            foreach (City x in this.Cities)
            {
                if (x.giveName() == name)
                {
                    return index;
                }
                index++;
            }

            Debug.WriteLine("error, no city found");
            return -1;
        }

        /// <summary>
        /// returns true or false depending if city is found in the list
        /// </summary>
        /// <returns></returns>
        public bool findCity(string name)
        {

            foreach (City x in this.Cities)
            {
                if (x.giveName()==name)
                {
                    return true;
                }
            }
            return false;

        }
        
        public List<City> giveCitiesList()
        {
            return this.Cities;
        }
        /// <summary>
        /// this will the lifeline of the system. On an outside timer, tick is called and all movement in the system happens
        /// every tick will move resources down the tradelines.
        /// </summary>
        public void tick()
        {
            //Handles the lines first
            foreach(TradeLine line in TradeLines)
            {
                line.tick();
            }
            //then cities "animate/do" with resources and calculate what they want to do
            foreach (City city in Cities)
            {
                city.doSomething();
            }
                
    }
    }
}