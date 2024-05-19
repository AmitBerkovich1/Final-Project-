namespace FinalProject.GeneticAlgorithm
{
    public interface MyEnums
    {
        enum Hours
        {
            BaseHours = 60,
            AdditonHours = 30,
            AdditionRoleHours = 10
        }
        enum Size
        {
            baseSize = 3,
            NumberOfRoles = 3,
            PopulationSize = 100
        }
        
        enum End
        {
            MaxWithNoImprovment = 10
        }

        enum Penalty
        {
            MaxPenalty = 100,
            Positive = 5
        }
        
        enum Precent
        {
            DescendantAmount = 4,
            BestParentsAmount = 5,
            TournamaentParentAmount = 15
        }

        enum Guesses
        {
            CorrectGuess = 1,
            Range = 20
        }
    }
}
