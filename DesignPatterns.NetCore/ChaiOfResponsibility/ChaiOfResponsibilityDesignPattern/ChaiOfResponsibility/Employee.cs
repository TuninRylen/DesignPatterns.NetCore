using ChaiOfResponsibilityDesignPattern.DAL;
using ChaiOfResponsibilityDesignPattern.Models;

namespace ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee T)
        {
            this.NextApprover = T;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
