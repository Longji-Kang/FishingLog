using Microsoft.EntityFrameworkCore;

namespace Fishing_API.Seeding.Seeders {
    public interface ISeeder<T> {
        public void seed(ModelBuilder modelBuilder, string execPath, params object[] args);
        public T[] returnBuiltObjects() {
            return null;
        }
    }
}
