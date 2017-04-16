namespace CampusSystem.Data
{
    public static class Initializer
    {
        public static void InitDb()
        {
            CampusSystemContext ctx = new CampusSystemContext();
            ctx.Database.Initialize(true);
        }
    }
}
