using CasinoSolution.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace AutomatedTests
{
    [TestClass]
    public class UnitTest1
    {
 

        [TestMethod, TestCategory("Interception")]
        public void CanInterceptCommand()
        {
          var repo = new SimpleRepository();
          var casinos= repo.GetAllCasinos();
            Assert.Inconclusive("Manually inspect bin/debug folder for Trace, Problems and Meta txt files");
        
        }


    }
}
