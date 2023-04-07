public class FieldReader<T>
{
    public List<T> ReadCsv(string filePath, Func<string[], T> parser)
    {
        var list = new List<T>();

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                var item = parser(values);

                list.Add(item);
            }
        }

        return list;
    }
}
