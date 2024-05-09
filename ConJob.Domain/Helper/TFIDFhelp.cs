using BlueSimilarity;
using BlueSimilarity.Containers;
using BlueSimilarity.Indexing;
using System.Collections;

namespace ConJob.Domain.Helper
{
    public static class TFIDFhelp
    {
        public static double TFIDFScore(string content, List<string> skills)
        {
            var words = content.Split(new[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var vocabulary = new SemanticVocabulary();
            vocabulary.AddSource(new DummyTokenizer());
            var skillsplit = new List<string>();
            skills.ForEach(s => skillsplit.AddRange(s.Split(new[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries)));
            var similar = new TFIDF(vocabulary);
            var score = similar.GetSimilarity(words, skillsplit.ToArray());
            return Math.Abs(score);
        }
    }

    public class DummyTokenizer : ITokenizer
    {
        private readonly string[] vocabulary = { "thì", "là", "mà", "ví dụ", "một", "nhưng", "mỗi" };
        private int currentIndex = -1;

        public string Current => vocabulary[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < vocabulary.Length;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
