using System.Diagnostics;

namespace TradeSystemSkelengton
{
    //trade good
    //type, current cost

        /// <summary>
        /// Resource,still havent decided if it should be independant of a city or not
        /// TODO: location
        /// </summary>
    internal class Resource
    {

        private enum Resourcetype { Wood, Spices, Food, RawGold, Currency, Iron }; //should this be here?
        private Resourcetype myResource; //type flag
        private int quantity=0;           //default
        private float basecost;         //base cost of myself
        private City myCity=null;   //city resource is attached to


        /// <summary>
        /// TODO add every avaliable type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        public Resource(string type,int quantity)
        {
            
            if(type==Resourcetype.Food.ToString())
            {
                myResource = Resourcetype.Food;
            }
            if (type == Resourcetype.Spices.ToString())
            {
                myResource = Resourcetype.Spices;
            }

            if (type == Resourcetype.Wood.ToString())
            {
                myResource = Resourcetype.Wood;
            }


        }

        /// <summary>
        /// todo city attachee
        /// </summary>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="myCity"></param>
        public Resource(string type, int quantity,City myCity)
        {

        }

        /// <summary>
        /// adds x quantity to resource
        /// </summary>
        public void addQuantity(int q)
        {
            this.quantity += q;
        }

        /// <summary>
        /// removes x quantity from resource
        /// </summary>
        public void removeQuanitity(int q)
        {
            if(safeQuantity(q))
            {
               this.quantity -= q;
            }
            else
            {
                Debug.WriteLine("problem in removeQuantity()");
            }
           
        }


        /// <summary>
        /// find out before you call removeQ
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool safeQuantity(int q)
        {
            if (this.quantity - q >= 0)
            {
                return true;
            }
            else
            {

                Debug.WriteLine("quantity is lower than 0");
                return false;
            }
        }

        /// <summary>
        /// attaches a resource to a city
        /// </summary>
        /// <param name="myCity"></param>
        public void attachToCity(City myCity)
        {
            this.myCity = myCity;
        }


        /// <summary>
        /// reports quantity of resource
        /// </summary>
        public int reportQuantity()
        {
            return this.quantity;
        }

       public string reportType()
        {
            return this.myResource.ToString();
        }

    }
}