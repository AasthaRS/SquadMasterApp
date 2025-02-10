
using SquadMaster.TeamGenerationLibrary.Models.Group;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using SquadMaster.TeamGenerationLibrary.Readers.FileReaders;
using SquadMaster.TeamGenerationLibrary.TeamGenerator;
using SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator;
using SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculatorFactory;

namespace SquadMaster.TeamGenerationLibrary
{
    public class MainTeamsGenerator 
    {

        private List<Member> _members;

        private List<Team> _teams;

        private IFileReader Reader { get; }

        private List<IDiversityCalculator> DiversityCalculators { get; }

        private ITeamGenerator TeamGenerator { get; set; }

        public MainTeamsGenerator() : this(teamCount: 2) { }

        public MainTeamsGenerator(int teamCount)
        {
            Reader = new JsonFileReader();

            _members = new List<Member>();

            _teams = new List<Team>();

            IDiversityCalculator gameDiversityCalculator = DiversityCalculatorFactory.CreateCalculator(DiversityType.Game, 1);
            IDiversityCalculator ageDiversityCalculator = DiversityCalculatorFactory.CreateCalculator(DiversityType.Age, 2);
            IDiversityCalculator genderDiversityCalculator = DiversityCalculatorFactory.CreateCalculator(DiversityType.Gender, 3);
            IDiversityCalculator departmentDiversityCalculator = DiversityCalculatorFactory.CreateCalculator(DiversityType.Department, 4);

            DiversityCalculators = new()
            {
                gameDiversityCalculator,
                ageDiversityCalculator,
                genderDiversityCalculator,
                departmentDiversityCalculator,
            };

            SetTeamGenerator(teamCount: teamCount, diversityCalculators: DiversityCalculators);
        }

        private void SetTeamGenerator(int teamCount, List<IDiversityCalculator> diversityCalculators)
        {
            ITeamGenerator teamGenerator = new TeamGenerator.TeamGenerator(teamCount: teamCount, diversityCalculators: diversityCalculators);
            TeamGenerator = teamGenerator;
        }

        public void SetTeamGenerator(int teamCount)
        {
            ITeamGenerator teamGenerator = new TeamGenerator.TeamGenerator(teamCount: teamCount, diversityCalculators: DiversityCalculators);
            TeamGenerator = teamGenerator;
        }

        public List<Member> ReadMembersFromJSON(string jsonFilePath)
        {
            List<Member> members = Reader.Read(filePath: jsonFilePath);
            _members = members;
            return _members;
        }

        public List<Team> GenerateTeams()
        {
            List<Team> teams = TeamGenerator.Generate(members: _members);
            _teams = teams;
            return _teams;
        }
    }

}
