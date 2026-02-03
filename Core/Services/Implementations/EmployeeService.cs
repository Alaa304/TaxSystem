using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// خدمة إدارة الموظفين (Business Logic Layer)
    /// مسؤولة عن تطبيق القواعد التجارية الخاصة بالموظفين
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// إضافة موظف جديد مع التحقق من عدم تكرار كود الموظف واسم المستخدم
        /// </summary>
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // استرجاع كل الموظفين لمراجعة التكرارات
            var employees = await _unitOfWork
                .GetRepository<Employee, int>()
                .GetAllAsync(true);

            // التحقق من عدم تكرار كود الموظف
            if (employees.Any(e => e.EmployeeCode == employee.EmployeeCode))
                throw new Exception("كود الموظف مستخدم بالفعل، برجاء إدخال كود آخر");

            // التحقق من عدم تكرار اسم المستخدم
            if (employees.Any(e => e.Username == employee.Username))
                throw new Exception("اسم المستخدم مستخدم بالفعل، برجاء اختيار اسم مستخدم آخر");

            // إضافة الموظف
            await _unitOfWork
                .GetRepository<Employee, int>()
                .AddAsync(employee);

            // حفظ التغييرات في قاعدة البيانات
            await _unitOfWork.SaveChangesAsync();

            return employee;
        }

        /// <summary>
        /// الحصول على موظف بواسطة رقم التعريف
        /// </summary>
        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await _unitOfWork
                .GetRepository<Employee, int>()
                .GetByIdAsync(employeeId);
        }

        /// <summary>
        /// الحصول على جميع الموظفين
        /// </summary>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork
                .GetRepository<Employee, int>()
                .GetAllAsync(true);
        }

        /// <summary>
        /// تحديث بيانات موظف موجود
        /// </summary>
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            // التحقق من وجود الموظف قبل التحديث
            var existingEmployee = await GetEmployeeByIdAsync(employee.Id);
            if (existingEmployee == null)
                throw new Exception("الموظف غير موجود");

            // تحديث بيانات الموظف
            _unitOfWork
                .GetRepository<Employee, int>()
                .Update(employee);

            // حفظ التغييرات
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// حذف موظف بواسطة رقم التعريف
        /// </summary>
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            // التحقق من وجود الموظف قبل الحذف
            var employee = await GetEmployeeByIdAsync(employeeId);
            if (employee == null)
                throw new Exception("الموظف غير موجود أو تم حذفه مسبقًا");

            // حذف الموظف
            _unitOfWork
                .GetRepository<Employee, int>()
                .Delete(employee);

            // حفظ التغييرات
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
