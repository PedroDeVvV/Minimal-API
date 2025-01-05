namespace ScreenSound.API.Requests;

public record ArtistaRequest(string nome, string bio);
public record ArtistaRequestEdit(int Id, string nome, string bio) : ArtistaRequest(nome, bio);

