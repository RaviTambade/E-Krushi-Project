package com.app.service;
import com.app.pojos.Employee;
import java.util.List;


public interface IEmployeeService {
    List<Employee> getAllEmployees();

    Employee getById(int empId);
    String delete(int empId);
    Employee newEmp(Employee employee);
    Employee updateEmp(Employee emp);
    


    
}
