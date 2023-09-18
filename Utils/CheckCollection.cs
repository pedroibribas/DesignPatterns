namespace Utils;

public class CheckCollection
{
    /// <summary>
    /// Verifica elementos duplicados no <see cref="IEnumerable{T}"/>.
    /// <para>Faz um laço na coleção para manter performance.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns>true se existirem elementos duplicados; false se não existirem.</returns>
    public static bool HasDuplicates<T>(IEnumerable<T> collection)
    {
        HashSet<T> set = new(); // Init coleção vazia

        foreach (var el in collection) // Laço
        {
            if (!set.Add(el)) // HashSet.Add retorna falso se o element já existe na coleção
                return true;
        }

        return false;
    }

    // Para mais formas de verificação de duplos:
    // https://www.milanjovanovic.tech/blog/5-ways-to-check-for-duplicates-in-collections
}