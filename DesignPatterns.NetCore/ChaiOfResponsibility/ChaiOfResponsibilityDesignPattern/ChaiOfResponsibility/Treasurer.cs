using ChaiOfResponsibilityDesignPattern.DAL;
using ChaiOfResponsibilityDesignPattern.Models;

namespace ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Ayşenur";
                customerProcess.Description = "Para Çekme işlemi onaylandı";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Ayşenur";
                customerProcess.Description = "Para çekme tutarı veznedarın limitini aştığı için işlem şube müdür yardımcısına yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }

        }
    }
}
