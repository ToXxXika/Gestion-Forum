using BL.Models;
using DAL.DataBaseContext;
using NUnit.Framework;
using PL.Controllers;

namespace PL.Test;

[TestFixture]
public class QueryHandlerTest
{
    private static readonly ForumDbContext _context;
    private LoginController Lc;
    [SetUp]
    public  void Setup()
    {
       
    }

    [Test]
    public void VerifyLogs()
    {
        Lc = new LoginController(_context);
        Login login = new Login();
        login.mail = "SSS";
        login.pwd= "SSS";
        var result = Lc.VerifyLogs(login);
        Assert.NotNull(result);
    }
}