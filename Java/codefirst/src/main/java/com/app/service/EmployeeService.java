package com.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import com.app.dao.EmployeeRepository;
import com.app.pojos.Employee;

@Service
@Transactional
public class EmployeeService implements IEmployeeService {
    
    @Autowired
    private EmployeeRepository empRepo;
    
    @Override
    public List<Employee> getAllEmployees(){
      return empRepo.findAll();
    }

    @Override
	public Employee getById(int empId) {
		// TODO Auto-generated method stub
		return empRepo.findById(empId)
        .orElseThrow(() -> new ResourceNotFoundException("Invalid emp id !!!!!!" + empId));
	}
    
    @Override
    public boolean delete(int empId){
        boolean mesg = false;

		if (empRepo.existsById(empId)) {
			empRepo.deleteById(empId);
			mesg = true;
		}

		return mesg;

    }
    @Override
    public Employee newEmp(Employee employee){
        return empRepo.save(employee);

    }

    @Override
    public Employee updateEmp(Employee emp){
        return empRepo.save(emp);
    }
}


