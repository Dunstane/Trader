using System.Collections.Generic;
using System.Diagnostics;

namespace TradeSystemSkelengton
{
    /// <summary>
    /// basic city, doesnt need to know much. maybe just who it's connected to and what they are sending eachother
    /// TODO:Needs and consumption, population?
    ///
    /// city types, differing needs and consumptions
    ///Artisan= Needs more food,produces more rare goods
    ///Agriculture= produces own food(lower consumption mod), poorer.
    ///
    /// Production: Start simple, expand.
    /// </summary>
    internal class City
    {
        private string name;
        private float xLoc;
        private float yLoc;
        private List<City> connectedCities; //cities I know
        private List<Resource> connectedResources; //resources I have
        private enum Citytype { Artisan, Agriculture }; //assigned to a city at creation
        /// <summary>
        /// default with no attached cities or resources
        /// </summary>
        /// <param name="name"></param>
        /// <param name="xLoc"></param>
        /// <param name="yLoc"></param>
        public City(string name, float xLoc, float yLoc)
        {
            this.name = name;
            this.yLoc = yLoc;
            this.xLoc = xLoc;

            connectedCities = new List<City>();
            connectedResources = new List<Resource>();
        }

        /// <summary>
        /// const with attached cities and resources
        /// </summary>
        /// <param name="name"></param>
        /// <param name="xLoc"></param>
        /// <param name="yLoc"></param>
        /// <param name="myResources"></param>
        /// <param name="myKnownCities"></param>
        public City(string name, float xLoc, float yLoc,List<Resource> myResources,List<City> myKnownCities)
        {
            this.name = name;
            this.yLoc = yLoc;
            this.xLoc = xLoc;

            connectedCities = new List<City>();
            connectedResources = new List<Resource>();

            if (myResources != null)
            {
                foreach(Resource res in myResources)
                {
                    connectedResources.Add(res);
                }
            }
            if (myKnownCities != null)
            {
                foreach (City city in myKnownCities)
                {
                    connectedCities.Add(city);
                }
            }
        }



        /// <summary>
        /// simple name grab accessor
        /// </summary>
        /// <returns></returns>
        public string giveName()
        {
            return this.name;
        }

        /// <summary>
        /// gives xLoc
        /// </summary>
        public float givexLoc()
        {
            return this.xLoc;
        }


        /// <summary>
        /// gives xLoc
        /// </summary>
        public float giveyLoc()
        {
            return this.yLoc;
        }


        //returns the list of resources the node has
        public List<Resource> giveResourceList()
        {
            return connectedResources;
        }



        /// <summary>
        /// method that consumes a tradeblock
        /// TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!********   Consuming of the blocks should maybe be done a level up, so city assignment can happen
        /// </summary>



        /// <summary>
        /// bool that checks if resource is already in list
        /// </summary>
        /// <returns></returns>
        public bool containsResource(string search)
        {
            foreach (Resource x in this.connectedResources)
            {
                 if (search == x.reportType())
                 {
                    return true;
                 }
    
            }
            return false;
        }

        /// <summary>
        /// returns the resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public Resource giveResource(string resource)
        {
            if (containsResource(resource))
            {
                foreach (Resource x in this.connectedResources)
                {
                    if (resource == x.reportType())
                    {
                        return x;
                    }

                }
            }
            Debug.WriteLine("null value!");
            return null;
        }

        public void addToResource(string type,int quantity)
        {
            if (containsResource(type))//I know i'm doing the same check over and over, but I like being sure since this is a public
            {
                giveResource(type).addQuantity(quantity);
            }
            else
            {
                Debug.WriteLine("Something went wrong in addToResource");
            }
        }
        //does something TBD, most likely will be part of the AI
        public void doSomething()
        {
            //needs to be based on need
            //consumption  use 30 wood to make 20 currency
            //random resource need that influences trade with neighbors
        }
    }
}