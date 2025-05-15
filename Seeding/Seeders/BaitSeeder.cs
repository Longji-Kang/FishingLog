using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class BaitSeeder : ISeeder<BaitModel> {
        private const string _FileLocation = "Baits.json";

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
                            int brandId = curr["BrandId"]!.GetValue<int>();
                            int baitTypeId = curr["BaitTypeId"]!.GetValue<int>();
                            string description = curr["Description"]!.ToString();

                            BaitModel baitModel = new BaitModel();
                            baitModel.Id = id;
                            baitModel.BrandId = brandId;
                            baitModel.BaitTypeId = baitTypeId;
                            baitModel.Description = description;

                            modelBuilder.Entity<BaitModel>(m => {
                                m.HasData(baitModel);
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
