namespace grupp5.Models;
public class TripSettings {

    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;

}

// This class will hold information about my connection URL, Database Name and Collection Name.
// All data that is class fields will be found in the "appsettings.json" file. I meant that we definer here in this class and we will be defined in "appsettings.json".