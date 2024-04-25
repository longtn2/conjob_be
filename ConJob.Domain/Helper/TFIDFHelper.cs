
namespace ConJob.Domain.Helper
{
    public static class TFIDFHelper
    {
        public static double CalculateTFIDFScore(string content, List<string> userSkills)
        {
            var words = content.Split(new[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var wordFrequency = CalculateTermFrequency(words);
            var idfScores = CalculateIDFScores(userSkills);
            return CalculateTFIDFScore(wordFrequency, idfScores, words.Length);
        }

        private static Dictionary<string, int> CalculateTermFrequency(string[] words)
        {
            var wordFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word] = 0;
                }
                wordFrequency[word]++;
            }
            return wordFrequency;
        }

        private static Dictionary<string, double> CalculateIDFScores(List<string> userSkills)
        {
            var numDocuments = 1; // Số lượng tài liệu, có thể cải thiện bằng cách sử dụng toàn bộ bộ sưu tập tài liệu
            var wordDocumentFrequency = new Dictionary<string, int>();
            foreach (var skill in userSkills)
            {
                if (!wordDocumentFrequency.ContainsKey(skill))
                {
                    wordDocumentFrequency[skill] = 0;
                }
                wordDocumentFrequency[skill]++;
            }

            var idfScores = new Dictionary<string, double>();
            foreach (var word in wordDocumentFrequency.Keys)
            {
                var idf = Math.Log((double)numDocuments / (wordDocumentFrequency[word] + 1));
                idfScores[word] = idf;
            }

            return idfScores;
        }

        private static double CalculateTFIDFScore(Dictionary<string, int> wordFrequency, Dictionary<string, double> idfScores, int totalWords)
        {
            var tfidfScore = 0.0;
            foreach (var word in wordFrequency.Keys)
            {
                var tf = (double)wordFrequency[word] / totalWords;
                if (idfScores.ContainsKey(word))
                {
                    tfidfScore += tf * idfScores[word];
                }
            }
            return Math.Abs(tfidfScore);
        }
    }
}
