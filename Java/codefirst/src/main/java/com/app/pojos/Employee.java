package com.app.pojos;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

// import org.springframework.format.annotation.DateTimeFormat;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
@Entity
@Table(name="employees")

public class Employee {
  @Id
  @GeneratedValue(strategy=GenerationType.IDENTITY)
  @JsonProperty("id")
  private Integer id;
  @Column(length=30)
  private String firstname;
  @Column(length=30)
  private String lastname;
  @Column(length=30)
  private Date birthdate;  
  @Column(length=30)
  private Date hiredate; 
  @Column(length=30)
  private String photo; 
  @Column(length=30)
  private Integer reportsto;
  @Column(length=30)
  private Integer userid;
}
