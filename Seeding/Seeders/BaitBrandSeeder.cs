using Fishing_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json.Nodes;

namespace Fishing_API.Seeding.Seeders {
    public class BaitBrandSeeder : ISeeder<BaitBrandModel> {
        private List<BaitBrandModel> baitBrandModels;

        public BaitBrandSeeder() {
            baitBrandModels = new List<BaitBrandModel>();
        }

        public void seed(ModelBuilder modelBuilder, string execPath, params object[] args) {
            string seedDataPath = $"{execPath}/Seeding/Data/BaitBrands.json";

            if (File.Exists(seedDataPath)) {
                string fileData = File.ReadAllText(seedDataPath);

                JsonNode? seedBaseNode = JsonNode.Parse(fileData);

                if (seedBaseNode != null) {
                    JsonArray? seedDataNode = seedBaseNode["data"]?.AsArray();

                    if (seedDataNode != null) {
                        foreach (JsonNode curr in seedDataNode!) {
                            int id = curr["Id"]!.GetValue<int>();
                            string brand = curr["Brand"]!.ToString();

                            BaitBrandModel baitBrandModel = new BaitBrandModel();
                            baitBrandModel.Id = id;
                            baitBrandModel.Brand = brand;

                            baitBrandModels.Add(baitBrandModel);

                            modelBuilder.Entity<BaitBrandModel>(m => {
                                m.HasData(baitBrandModel);
                            });
                        }
                    } else {
                        throw new InvalidDataException("Data in BaitBrands.json data block is invalid");
                    }
                } else {
                    throw new InvalidDataException("Data in BaitBrands.json is invalid");
                }

            } else {
                throw new FileNotFoundException($"Seed file 'BaitBrands.json' does not exist at {seedDataPath}");
            }
        }

        public BaitBrandModel[] returnBuiltObjects() {
            return baitBrandModels.ToArray();
        }
    }
}
