using Microsoft.AspNetCore.Mvc;
using test_7.Data;
using test_7.Model;
// 弃用组件
public interface IDepartmentService
{
    public Task AddAsync(Department d);
    public Task UpdateAsync(List<Department> DeptList);
    public Task DeleteAsync(int Id);
    public Task<ActionResult<List<Department>>> GetByIdAsync(int Id);
    public Task<List<Department>> GetAllAsync();


}
