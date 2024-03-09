using ChaiOfResponsibilityDesignPattern.DAL;
using ChaiOfResponsibilityDesignPattern.Models;

namespace ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {

            Context context = new Context();

            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Uğur can çelik";
                customerProcess.Description = "Para Çekme işlemi onaylandı";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Uğur can çelik";
                customerProcess.Description = "Para çekme tutarı şube müdürünün limitini aştığı için işlem bölge müdürüne yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }


        }
    }
}
