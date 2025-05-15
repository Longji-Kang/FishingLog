using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class RigSeeder : ISeeder<RigsModel> {
        private const string _FileLocation = "Rigs.json";

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
                            string rigName = curr["RigName"]!.ToString();

                            RigsModel rigModel = new RigsModel();
                            rigModel.Id = id;
                            rigModel.RigName = rigName;

                            modelBuilder.Entity<RigsModel>(m => {
                                m.HasData(rigModel);
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
