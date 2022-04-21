namespace BootcampProject.Domain.MongoDbEntities
{
    public interface IUserStoreDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string conn { get; set; }
        public string DatabaseName { get; set; }        
    }
}
