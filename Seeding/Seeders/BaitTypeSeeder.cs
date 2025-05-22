using Fishing_API.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class BaitTypeSeeder : ISeeder<BaitTypeModel> {
        private List<BaitTypeModel> _baitTypeList;

        private const string _FileLocation = "BaitTypes.json";

        public BaitTypeSeeder() {
            _baitTypeList = new List<BaitTypeModel>();
        }

        public void seed(ModelBuilder modelBuilder, string execPath) {
            string seedDataPath = $"{execPath}/Seeding/Data/{_FileLocation}";

            if (File.Exists(seedDataPath)) {
                string fileData = File.ReadAllText(seedDataPath);

                JsonNode? seedBaseNode = JsonNode.Parse(fileData);

                if (seedBaseNode != null) {
                    JsonArray? seedDataNode = seedBaseNode["data"]?.AsArray();

                    if (seedDataNode != null) {
                        foreach (JsonNode curr in seedDataNode!) {
                            int id = curr["Id"]!.GetValue<int>();
                            string type = curr["Type"]!.ToString();

                            BaitTypeModel baitTypeModel = new BaitTypeModel();
                            baitTypeModel.Id = id;
                            baitTypeModel.Type = type;

                            _baitTypeList.Add(baitTypeModel);

                            modelBuilder.Entity<BaitTypeModel>(m => {
                                m.HasData(baitTypeModel);
                            });
                        }
                    } else {
                        throw new InvalidDataException($"Data in {_FileLocation} data block is invalid");
                    }
                } else {
                    throw new InvalidDataException($"Data in {_FileLocation} is invalid");
                }

            } else {
                throw new FileNotFoundException($"Seed file '{_FileLocation}' does not exist at {seedDataPath}");
            }
        }
    }
}
