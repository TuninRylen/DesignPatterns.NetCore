using ChaiOfResponsibilityDesignPattern.DAL;
using ChaiOfResponsibilityDesignPattern.Models;

namespace ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility
{
    public class AreaDiractor : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü - Ayşenur karaçar";
                customerProcess.Description = "Para Çekme işlemi onaylandı";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü - Ayşenur karaçar";
                customerProcess.Description = "Para çekme işlemi gerçekleşemedi. Günde 400.000 bin liradan fazla para çekemezsiniz. Farklı günlerde çekiniz.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
