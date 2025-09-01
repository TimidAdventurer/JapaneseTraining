using JapaneseTraining.Model;

namespace JapaneseTraining
{
    /// <summary>
    /// 与单词相关的操作
    /// </summary>
    public class WordManager
    {
        /// <summary>
        /// 将string型词性转换成Pos类型
        /// </summary>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Pos ConvertStringToPos(string before)
        {
            Pos after = new Pos();
            switch (Convert.ToInt16(before))
            {
                case 0: after = Pos.None; break;
                case 1: after = Pos.Nouns; break;
                case 2: after = Pos.Verbs; break;
                case 3: after = Pos.Adjectives; break;
                case 4: after = Pos.Adverbs; break;
                case 5: after = Pos.Particles; break;
                case 6: after = Pos.Conjunctions; break;
                default: after = Pos.None; break;//后续添加属性
            }
            return after;
        }
    }
}
