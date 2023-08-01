 package com.app.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.app.pojos.Employee;
import com.app.service.IEmployeeService;

@RestController // MANDATORY : composed of @Controller at the cls level + @ResponseBody(for
				// marshalling : java ---> json) addedd implicitly on ret types of all req
				// handling methods , annotated by @ReqMapping / @GetMapping .......
@RequestMapping("/api/employees")
@CrossOrigin(origins = "http://localhost:3000")
public class EmployeeController {
	//dep : emp service i/f
	@Autowired
	private IEmployeeService empService;
	
	public EmployeeController() {
		System.out.println("in ctor of " + getClass());
	}
	//add req handling method (REST API call) to send all emps
	@GetMapping
	public List<Employee> listAllEmps()
	{
		System.out.println("in list emps");
		return empService.getAllEmployees();		
	}
	//add req handling method to create new emp
	@PostMapping
	public Employee saveEmpDetails(@RequestBody  Employee emp)
	//To inform SC , to un marshall(de-serialization , json/xml  --> Java obj) the method arg.
	{
		System.out.println("in save emp "+emp);//id : null...
		return empService.newEmp(emp);
	}
	//add req handling method to delete emp details
	@DeleteMapping("/{empId}")//can use ANY name for a path var.
	//@PathVariable => a binding between a path var to method arg.
	public String deleteEmpDetails(@PathVariable int empId)
	{
		System.out.println("in del emp "+empId);
		return empService.delete(empId);
	}
	//add a method to get specific emp dtls
	@GetMapping("/{id}")
	//@PathVariable => a binding between a path var to method arg.
	public Employee getEmpDetails(@PathVariable int id)
	{
		System.out.println("in get emp "+id);
		return empService.getById(id);
	}
	//add a method to update existing resource
	@PutMapping
	public Employee updateEmpDetails(@RequestBody Employee emp)
	{
		System.out.println("in update emp "+emp);//id not null
		return empService.updateEmp(emp);
	}
}

    

