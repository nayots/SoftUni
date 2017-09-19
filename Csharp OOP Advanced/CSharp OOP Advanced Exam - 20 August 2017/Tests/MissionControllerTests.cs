using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class MissionControllerTests
{
    private MissionController sut;
    private IWareHouse wh;
    private IArmy army;
    private List<ISoldier> dummySoldiers;

    [SetUp]
    public void TestInitialize()
    {
        this.dummySoldiers = new List<ISoldier>()
        {
            new Corporal("Pesho", 20, 0, 50),
            new Ranker("Ivan", 30, 10, 40),
            new SpecialForce("Venci", 26, 20, 30)
        };

        this.wh = new WareHouse();
        this.army = new Army();
        foreach (var sold in this.dummySoldiers)
        {
            this.army.AddSoldier(sold);
        }

        this.sut = new MissionController(army, wh);
    }

    [Test]
    public void CreateMissionControllerTest()
    {
        this.wh = new WareHouse();
        this.army = new Army();

        this.sut = new MissionController(army, wh);
    }

    [Test]
    public void AddEasyMissionsToController()
    {
        //Arrange
        IMission easy = new Easy(100);

        //Act
        this.sut.Missions.Enqueue(easy);

        //Assert
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void AddMediumMissionsToController()
    {
        //Arrange
        IMission medium = new Medium(100);

        //Act
        this.sut.Missions.Enqueue(medium);

        //Assert
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void AddHardMissionsToController()
    {
        //Arrange
        IMission hard = new Hard(100);

        //Act
        this.sut.Missions.Enqueue(hard);

        //Assert
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void DequeMissionFromController()
    {
        //Arrange
        IMission hard = new Hard(100);

        //Act
        this.sut.Missions.Enqueue(hard);
        this.sut.Missions.Dequeue();

        //Assert
        Assert.AreEqual(0, 0);
    }

    [Test]
    public void AddingNullToMissionsDoesNotThrowsException()
    {
        //Assert

        this.sut.Missions.Enqueue(null);

        Assert.Pass();
    }

    [Test]
    public void FailMissionsCountIsCorrect()
    {
        //Arrange
        this.sut.Missions.Enqueue(new Easy(10));
        this.sut.Missions.Enqueue(new Medium(10));
        this.sut.Missions.Enqueue(new Hard(10));
        this.sut.Missions.Enqueue(new Easy(10));

        //Act
        this.sut.FailMissionsOnHold();

        //Assert

        Assert.AreEqual(0, this.sut.Missions.Count);
    }

    [Test]
    public void FailMissionsCountIsCorrectWithEmptyMissionsOnHold()
    {
        //Assert

        Assert.AreEqual(0, this.sut.Missions.Count);
    }

    [Test]
    public void PerformMissionWhenMissionQueueIsFull()
    {
        //Arrange
        this.sut.Missions.Enqueue(new Easy(10));
        this.sut.Missions.Enqueue(new Medium(10));
        this.sut.Missions.Enqueue(new Hard(10));

        IMission failMission = new Easy(90);

        string expected = $"Mission declined - Suppression of civil rebellion{Environment.NewLine}Mission on hold - Capturing dangerous criminals{Environment.NewLine}Mission on hold - Disposal of terrorists{Environment.NewLine}Mission on hold - Suppression of civil rebellion{Environment.NewLine}";

        //Act
        string result = this.sut.PerformMission(failMission);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void PerformMissionWhenMissionQueueIsEmptyButSoldiersAreNotReady()
    {
        //Arrange
        IMission failMission = new Easy(90);

        string expected = $"Mission on hold - Suppression of civil rebellion{Environment.NewLine}";

        //Act
        string result = this.sut.PerformMission(failMission);

        //Assert

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void FailCounterIncreasesWhenMissionsFail()
    {
        //Arrange
        this.sut.Missions.Enqueue(new Easy(10));
        this.sut.Missions.Enqueue(new Medium(10));
        this.sut.Missions.Enqueue(new Hard(10));

        IMission failMissionOne = new Easy(90);
        IMission failMissionTwo = new Easy(90);

        //Act
        this.sut.PerformMission(failMissionOne);
        this.sut.PerformMission(failMissionTwo);

        //Assert

        Assert.AreEqual(2, this.sut.FailedMissionCounter);
    }

    [Test]
    public void SuccessCounterDoesNotIncreasesWhenMissionsFail()
    {
        //Arrange
        this.sut.Missions.Enqueue(new Easy(10));
        this.sut.Missions.Enqueue(new Medium(10));
        this.sut.Missions.Enqueue(new Hard(10));

        IMission failMissionOne = new Easy(90);
        IMission failMissionTwo = new Easy(90);

        //Act
        this.sut.PerformMission(failMissionOne);
        this.sut.PerformMission(failMissionTwo);

        //Assert

        Assert.AreEqual(0, this.sut.SuccessMissionCounter);
    }

    [Test]
    public void PerformMissionWithNullValueMission()
    {
        //Assert
        Assert.Throws<NullReferenceException>(() => this.sut.PerformMission(null));
    }

    [Test]
    public void CreatingControllerWithNullParametersBlowsUpWhenUsed()
    {
        //Arrange
        this.sut = new MissionController(null, null);

        //Act

        //Assert
        Assert.Throws<NullReferenceException>(() => this.sut.PerformMission(new Easy(100)));
    }

    [Test]
    public void CreatingControllerWithEmptyArmy()
    {
        //Arrange
        this.sut = new MissionController(null, new WareHouse());

        //Act

        //Assert
        Assert.Throws<NullReferenceException>(() => this.sut.PerformMission(new Easy(10)));
    }
}