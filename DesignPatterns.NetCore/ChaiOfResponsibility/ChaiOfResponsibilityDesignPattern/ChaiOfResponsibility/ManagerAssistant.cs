using ChaiOfResponsibilityDesignPattern.DAL;
using ChaiOfResponsibilityDesignPattern.Models;

namespace ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Uğur";
                customerProcess.Description = "Para Çekme işlemi onaylandı";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Uğur";
                customerProcess.Description = "Para çekme tutarı şube müdür yardımcısının limitini aştığı için işlem şube müdürüne yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
