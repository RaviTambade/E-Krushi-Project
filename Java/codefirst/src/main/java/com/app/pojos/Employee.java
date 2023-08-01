package com.app.pojos;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
@Entity
@Table(name="employe")

public class Employee {
  @Id
  @GeneratedValue(strategy=GenerationType.IDENTITY)
  @JsonProperty("id")
  private Integer EmpId;
  @Column(length=30)
  private String name;
  @Column(length=30)
  private String department;
  @JsonProperty("location")
  @Column(length=30)
  private String workLocation;  
}
