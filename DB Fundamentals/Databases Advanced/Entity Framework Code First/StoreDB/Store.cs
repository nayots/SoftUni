namespace StoreDB
{
    class Store
    {
        static void Main(string[] args)
        {
            var context = new StoreDBContext();
            context.Database.Initialize(true);
            //1.	Local Store
            //2.	Local Store Improvement
            //Sample Data is in The Initializer
            //When the model is changed it drops and remakes the DB with the seed data
        }
    }
}
