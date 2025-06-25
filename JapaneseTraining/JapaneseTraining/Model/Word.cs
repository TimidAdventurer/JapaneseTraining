namespace JapaneseTraining.Model
{
    public class Word
    {
        /// <summary>
        /// 中文翻译
        /// </summary>
        public string Chinese { get; set; }
        /// <summary>
        /// 日文
        /// </summary>
        public string Japanese { get; set; }
        /// <summary>
        /// 词性
        /// </summary>
        public Pos pos { get; set; }

    }
    public enum Pos
    {
        //名词、动词、形容词、副词、助词、连词
        None,
        Nouns,
        Verbs,
        Adjectives,
        Adverbs,
        Particles,
        Conjunctions
    }
}
