namespace A_Entity
{
    public class SessionState
    {
        public int score { get; set; }
        public int coin { get; set; }

        public SessionState(int score,int coin)
        {
            this.score = score;
            this.coin = coin;
        }

        public override string ToString()
        {
            return $"Score is {score}, coin is {coin}";
        }
    }
}
