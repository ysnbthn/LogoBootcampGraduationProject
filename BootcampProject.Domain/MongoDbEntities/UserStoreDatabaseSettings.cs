namespace BootcampProject.Domain.MongoDbEntities
{
    public class UserStoreDatabaseSettings : IUserStoreDatabaseSettings
    {
        public string CollectionName { get; set; } = string.Empty;
        public string conn { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
