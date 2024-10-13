namespace GameZone.Services;

public interface IGamesService
{
    IEnumerable<Game> GetAll(string searchTerm = null, int? categoryId = null, int? deviceId = null);

    Game? GetById(int id);
    Task Create(CreateGameFormViewModel model);
    Task<Game?> Update(EditGameFormViewModel model);
    bool Delete(int id);
}