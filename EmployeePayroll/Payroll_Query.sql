
--UC1
Create database payroll_service;

use payroll_service;


--UC2
Create table employee_payroll(
id int primary key identity(1,1),
name varchar(30),
salary varchar(30),
start_date date
);
--UC3
Insert into employee_payroll(name,salary,start_date)values('a','1000','2018-01-01');
Insert into employee_payroll(name,salary,start_date)values('b','2000','2018-01-01');
Insert into employee_payroll(name,salary,start_date)values('c','3000','2018-01-01');
Insert into employee_payroll(name,salary,start_date)values('d','4000','2018-01-01');

--UC4
Select*from employee_payroll;

--UC5
Select*from employee_payroll where name='b';
Select*from employee_payroll where start_date between cast('2018-01-01'as Date) and GetDate();

--UC6
Alter table employee_payroll Add Gender Char(1);


Update employee_payroll set gender='F' where id=1;
Update employee_payroll set gender='F' where id=2;
Update employee_payroll set gender='F' where id=3;
Update employee_payroll set gender='F' where id=4;

--UC7
Select Sum(cast(salary as bigint)) from employee_payroll;
Select AVG(cast(salary as bigint)) from employee_payroll;
Select MIN(cast(salary as bigint)) from employee_payroll;
Select Max(cast(salary as bigint)) from employee_payroll;

Select gender,count(*) from employee_payroll group by(gender);

--UC8
Alter table employee_payroll Add phone VARCHAR(10);
Alter table employee_payroll Add Address VARCHAR(30);
Alter table employee_payroll Add Department VARCHAR(20);


--UC9
Alter table employee_payroll Add basic_pay bigint,deductions bigint,taxable_pay bigint,income_tax bigint,net_pay bigint;

--UC10
Insert into employee_payroll(name, salary, start_date, gender, phone, address, department, basic_pay, deductions, taxable_pay, income_tax, net_pay) values
('Terissa', '10000', '2018-01-01', 'F', '1234567899', 'Chennai', 'Sales', '2000', '500', '250', '100', '1000'); 
 
Insert into employee_payroll(name, salary, start_date, gender, phone, address, department, basic_pay, deductions, taxable_pay, income_tax, net_pay) values
('Terissa', '10000', '2018-01-01', 'F', '1234567899', 'Chennai', 'Marketing', '2000', '500', '250', '100', '1000');

Create table Salary(salId int primary key identity(1,1), salary bigint, basic_pay bigint, deductions bigint,taxable_pay bigint, income_tax bigint,net_pay bigint);

Create table department(depId int primary key identity(1,1),Dept_nam varchar(20));

Create table employee(id int primary key identity(1,1), name varchar(20), start_date date, phone varchar(10), address varchar(30),salId int Foreign Key References salary(salId));

Create table emp_department_mapping(id int primary key identity(1,1), empId int Foreign Key References employee(id),deptId int Foreign Key References department(depId));


Insert into salary(salary,basic_pay,deductions,taxable_pay,income_tax,net_pay)values('20000','9000','400','50','78','3000');
Insert into salary(salary,basic_pay,deductions,taxable_pay,income_tax,net_pay)values('30000','8000','400','50','78','3000');
Insert into salary(salary,basic_pay,deductions,taxable_pay,income_tax,net_pay)values('40000','6000','400','50','78','3000');




Select * from salary;
Insert into department(Dept_nam)values('Sales');
Select * from department;
Insert into employee(name,start_date,phone,address,salId)values('Soundarya','2023-08-07','1112223334','TamilNadu',1);
Insert into employee(name,start_date,phone,address,salId)values('Shree','2023-07-05','1112223334','Bengaluru',1);
Select * from employee;
Insert into emp_department_mapping(empId,deptId)values('1','1');
Select * from emp_department_mapping;

delete from emp_department_mapping where id=2;

SELECT *FROM employee INNER JOIN salary ON employee.salId=salary.salId;




 --Stored Procedure
Create procedure AddEmployee_payroll
(
@name varchar(20),
@salary varchar(20),
@start_date date,
@gender Char(1),
@phone varchar(10), 
@address varchar(30), 
@department varchar(20),
@basic_pay bigint,
@deductions bigint,
@taxable_pay bigint,
@income_tax bigint,
@net_pay bigint
)
As
Begin
Insert into employee_payroll(name,salary,start_date,gender,phone,address,department,basic_pay,deductions,taxable_pay,income_tax,net_pay) 
values(@name,@salary,@start_date,@gender,@phone,@address,@department,@basic_pay,@deductions,@taxable_pay,@income_tax,@net_pay)
End

 

Create procedure GetAllEmployee_payroll
As
Begin
Select * from employee_payroll
End

select * from employee_payroll;
delete from employee_payroll Where name='d';

Create procedure DeleteEmployee_payroll
(
    @Id int
)
As
Begin
Delete from employee_payroll where Id=@Id;
End

 

Create procedure UpdateEmployee_payroll
(
    @Id int,
    @name varchar(20),
    @salary varchar(20),
    @start_date date,
    @gender Char(1),
    @phone varchar(10), 
    @address varchar(30), 
    @department varchar(20),
    @basic_pay bigint,
    @deductions bigint,
    @taxable_pay bigint,
    @income_tax bigint,
    @net_pay bigint
)
As 
Begin
Update employee_payroll set name=@name, salary=@salary, start_date=@start_date, gender = @gender, phone = @phone, address = @address,
department = @department, basic_pay = @basic_pay, deductions = @deductions, taxable_pay = @taxable_pay, income_tax = @income_tax, net_pay = @net_pay
where Id=@Id
End

 Create Procedure Range(
@start_date date
)
As
Begin
Select * from employee_payroll where start_date between CAST(@start_date as Date) and GETDATE();
End

Create Procedure Calculations
As
Begin
Select 
Sum(cast(salary as bigint))as Sum , 
Avg(cast(salary as bigint))as Avg,
Min(cast(salary as bigint))as Min,
Max(cast(salary as bigint))as Max from employee_payroll; 
End
Select e.*,d.* from employee e,department d where e.emp_id = d.dep_id and e.emp_id = 1;

UPDATE employee_payroll
SET gender = 'F', phone = 1092837465, address = 'Chennai', department ='IT', basic_pay = 8000, 
deductions = 2000, taxable_pay = 500, income_tax = 200, net_pay = 3000
WHERE name = 'Soundarya';

EXEC GetAllEmployee_payroll;