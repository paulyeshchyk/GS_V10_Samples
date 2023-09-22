using _7_1.SampleClasses;

namespace _7_1_3
{
  public static class Program_7_1_3
  {
    public static ContractorClass? AddContractor()
    {
      return new ContractorClass() { Name = "Contractor1" };
    }

    public static DocumentClass? AddDocument()
    {
      return new DocumentClass() { Name = "Document1" };
    }

    public static DocumentContractorClass? AddDocumentContractor(DocumentClass? document, ContractorClass? contractor)
    {
      if (document == null || contractor == null)
      {
        return null;
      }

      return new DocumentContractorClass() { DocumentLink = document, ContractorLink = contractor };
    }

    [STAThread]
    private static void Main(string[] args)
    {
      var contractor = AddContractor();
      Console.WriteLine(value: $"Создан исполнитель {contractor?.Name}");
      var document = AddDocument();
      Console.WriteLine($"Создан документ {document?.Name}");
      var documentContractor = AddDocumentContractor(document, contractor);
      if (documentContractor == null)
      {
        return;
      };
      var status = documentContractor.IsValid ? "Действителен" : "Недействителен";
      Console.WriteLine($"Создана связь между исполнителем и документом; идентификатор связи: {documentContractor?.Identifier}; подтверждением чему является статус документа: {status} ");
      Console.WriteLine();
      Console.WriteLine("Нажмите на любую клавишу для разрыва связи между исполнителем и документом");
      Console.ReadKey();

      documentContractor.ContractorLink = null;
      documentContractor.DocumentLink = null;
      var status1 = documentContractor.IsValid ? "Действителен" : "Недействителен";
      Console.WriteLine();
      Console.WriteLine($"Связь разорвана между исполнителем и документом; идентификатор связи: {documentContractor?.Identifier}; подтверждением чему является статус документа: {status1} ");
      Console.ReadKey();
    }
  }
}