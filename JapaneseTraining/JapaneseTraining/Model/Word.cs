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
        None,
        Nouns,//名词
        Verbs,//动词
        Adjectives,//形容词
        Adverbs,//副词
        Particles,//助词
        Conjunctions//连词
    }
}
