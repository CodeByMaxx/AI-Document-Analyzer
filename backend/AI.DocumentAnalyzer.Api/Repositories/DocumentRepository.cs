using AI.DocumentAnalyzer.Api.Models;

namespace AI.DocumentAnalyzer.Api.Repositories;

public class DocumentRepository
{
    private readonly List<Document> _documents = new();


    public void Add(Document document)
    {
        _documents.Add(document);
    }


    public Document? Get(Guid id)
    {
        return _documents.FirstOrDefault(
            x => x.Id == id
        );
    }


    public IEnumerable<Document> GetAll()
    {
        return _documents;
    }
}
