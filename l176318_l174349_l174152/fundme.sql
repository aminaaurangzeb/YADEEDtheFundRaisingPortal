drop database fundme;
go
create database fundme;
go
use fundme;

 go
create table myuser(
email varchar(30) NOT NULL,--fk --pk
passcode varchar(20),
name varchar(20),
dob date,
gender char(1),
phoneno char(13),--+92 format will be accepted
cnic char(13) UNIQUE
) --add cnic

create table donor(
email varchar(30) NOT NULL, --fk --pk
accountno varchar(20),
visitingaddress varchar(50),
medals char(10)
)
create table volunteer(
email varchar(30) NOT NULL,--fk --pk1
eventid int NOT NULL,--pk2
position char(30)
)

create table myadmin(
email varchar(30) NOT NULL,--pk --fk
position char(30), --add password && cnic 
passcode varchar(20),
cnic varchar(13) UNIQUE
)

create table donations(
email varchar(30) NOT NULL,--fk --pk1
caseid int NOT NULL,--pk2
amount_donated int
)
create table cases(
caseid int NOT NULL,--pk
name varchar(20),
category varchar(20),
target_amount int,
linktocustomer char(20) --website or emailid
)
create table myevent(
eventid int NOT NULL,--pk
name varchar(20),
category varchar(20),
eventDate date,
linktoeventpage char(20) --website or emailid
)

create table flaggedcase
(
email varchar(30) NOT NULL,
caseid int NOT NULL

)

create table visitrequest
(
email varchar(30) NOT NULL,
eventid int NOT NULL

)

--Alter Table myuser Alter column email char NOT NULL
alter table myuser add constraint PK_myuser primary key(email)
--alter table myuser add constraint FK_myuser foreign key(email) references cnic (email) on delete cascade on update cascade

--Alter Table donor Alter column email char NOT NULL
alter table donor add constraint PK_dmyuser primary key(email) 
alter table donor add constraint FK_demail foreign key(email) references myuser(email) on delete cascade on update cascade

--Alter Table volunteer Alter column email char NOT NULL
--Alter Table volunteer Alter column eventid int NOT NULL
alter table volunteer add constraint PK_vemailid primary key(email, eventid)
alter table volunteer add constraint FK_vemail foreign key(email) references myuser(email) on delete cascade on update cascade


--Alter Table myadmin Alter column email char NOT NULL
alter table myadmin add constraint PK_memailid primary key(email)


--Alter Table donations Alter column email char NOT NULL
--Alter Table donations Alter column caseid int NOT NULL
alter table donations add constraint PK_demailid primary key(email, caseid)
alter table donations add constraint FK_dfk foreign key(email) references myuser(email) on delete cascade on update cascade


--Alter Table cases Alter column caseid int NOT NULL
alter table cases add constraint PK_caseid primary key(caseid)

--Alter Table myevent Alter column eventid int NOT NULL
alter table myevent add constraint PK_eventid primary key(eventid)

--alter table flagged
 
alter table flaggedcase add constraint pk_flaggedcase primary key(email, caseid)
alter table flaggedcase add constraint fk_flaggedcase1 foreign key(email) references myuser(email) on delete cascade on update cascade
alter table flaggedcase add constraint fk_flaggedcase2 foreign key(caseid) references cases(caseid) on delete cascade on update cascade

--alter table visit request
alter table visitrequest add constraint pk_visitrequest primary key(email, eventid)
alter table visitrequest add constraint fk_visitrequest1 foreign key(email) references myuser(email) on delete cascade on update cascade
alter table visitrequest add constraint fk_visitrequest2 foreign key(eventid) references myevent(eventid) on delete cascade on update cascade



insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('laraib@blah.com', 'laraibsucks1', 'laraibsucks','1992-09-9', 'F', 301-0000000, 3333333333331)
insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('raima@blah.com', 'raimasucks1', 'raimasucks','1992-02-23', 'F', 302-0000000, 3333333333332)
insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('noorish@blah.com', 'noorishsucks1', 'noorishsucks','1998-01-9', 'F', 303-0000000, 3333333333333)
insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('asfand@blah.com', 'asfandsucks1', 'asfandsucks','1982-08-9', 'M', 304-0000000, 3333333333334)
insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('ali@blah.com', 'alisucks1', 'alisucks','1997-08-8', 'M', 305-0000000, 3333333333335)
insert into myuser (email ,passcode,name, dob,gender ,phoneno ,cnic ) values ('amina@blah.com', 'aminasucks1', 'aminasucks','1998-08-8', 'F', 306-0000000, 3333333333336)

insert into donor(email, accountno, visitingaddress,medals) values ('laraib@blah.com',1,'suigas','gold')
insert into donor(email, accountno, visitingaddress,medals) values ('raima@blah.com',2,'modeltown','silver')
insert into donor(email, accountno, visitingaddress,medals) values ('noorish@blah.com',3,'fha','bronze')
insert into donor(email, accountno, visitingaddress,medals) values ('asfand@blah.com',4,'gardentown','-')
insert into donor(email, accountno, visitingaddress,medals) values ('ali@blah.com',5,'anarkali','bronze')

insert into volunteer(email,eventid,position) values ('laraib@blah.com', 1, 'manager')
insert into volunteer(email,eventid,position) values ('raima@blah.com', 1, 'electrician')
insert into volunteer(email,eventid,position) values ('ali@blah.com', 2, 'plumber')

insert into myadmin(email,position,passcode,cnic) values ('amina@blah.com', 'ceo', 'aminasucks1', 3333333333336)
insert into myadmin(email,position,passcode,cnic) values ('hammad@blah.com', 'officeboy', 'hammadsucks1', 3333333333337) 
insert into myadmin(email,position,passcode,cnic) values ('raima1@blah.com', 'chairwoman', 'raima', 3333333333337) 

insert into donations(email,caseid,amount_donated) values ('noorish@blah.com', 7, 55) 
insert into donations(email,caseid,amount_donated) values ('noorish@blah.com', 8, 95) 
insert into donations(email,caseid,amount_donated) values ('asfand@blah.com', 7, 85) 
insert into donations(email,caseid,amount_donated) values ('laraib@blah.com', 7, 555) 
insert into donations(email,caseid,amount_donated) values ('laraib@blah.com', 3, 855) 
insert into donations(email,caseid,amount_donated) values ('laraib@blah.com', 8, 955) 

insert into cases(caseid, name, category ,target_amount ,linktocustomer) values (7,'eduforall','education', 5000, 'eduforall.com')
insert into cases(caseid, name, category ,target_amount ,linktocustomer) values (8,'healthforall','health', 70000, 'healthforall.com')
insert into cases(caseid, name, category ,target_amount ,linktocustomer) values (3,'edu','education', 9900,  'edu.com')
insert into cases(caseid, name, category ,target_amount ,linktocustomer) values (4,'abc','education', 9900,  'edu.com')


insert into myevent(eventid,name,category,eventDate ,linktoeventpage) values (1,'funfairspecialpeople', 'charity', '2019-09-8','special children')
insert into myevent(eventid,name,category,eventDate ,linktoeventpage) values (2,'oldpeople', 'charity', '2020-09-8','oldpeople.com')
insert into myevent(eventid,name,category,eventDate ,linktoeventpage) values (3,'sad people', 'charity', '2020-09-8','oldpeople.com')

insert into flaggedcase values ('laraib@blah.com', 4)
insert into flaggedcase values ('noorish@blah.com', 4)

insert into visitrequest values('laraib@blah.com', 3)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc signUp 
@name varchar(20),
@email varchar(30),
@password varchar(20), 
@phone varchar(13), 
@dob date,
@gender char(1),
@done int OUTPUT,
@cnic varchar(13)
as
begin
	set @done=1
	if(@dob >= getdate())
	begin
		set @done=0
		print 'Oh! Seems like you are not born yet! The date of Birth you enetered is not valid. See you in future.'
	end
	if(@email not like '%@%')
	begin
		set @done=0
		print 'The email you provided has wrong syntax.'
	end
	if(@email = any (select u.email from myuser u))
	begin
		set @done=0
		print 'The email you provided is already registered. Use some other email to register a new account or sign in using this email.'
	end
	if (exists (select * from myuser where @cnic=cnic))
	begin
		print' cnic has to be unique'
		set @done =0
	end
	if(@done=1)
	begin
		insert into myuser values (@email,@password,@name,@dob,@gender,@phone,@cnic)--add record
		(select * from myuser u where u.email=@email)--display personal record for signed up page
	end
end

declare @mydone int;
exec signUp 
@name ='raima',
@email= 'ag54@gmail.com',
@password ='dancing', 
@phone ='+923214567890', 
@dob ='1999-4-2',
@gender ='F',
@cnic ='5454832211234',
@done=@mydone output
select @mydone

select * from myuser


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc signIn 
@email varchar(30),
@password varchar(20),
@done int OUTPUT
as
begin
	if (exists ( select * from myuser U where U.email = @email and U.passcode=@password))
	begin
		set	@done=1 
		print 'You are Signed in'
	end
	else 
	begin
		set @done=0
		print 'Sorry Incorrect Email or Password'
	end

end

declare @mydone int;
exec signIn 
@email= 'ali@blah.com',
@password ='alisucks1', 
@done=@mydone output
select @mydone

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc adminsignin
@emailid varchar(30),
@password varchar(20),
@done int OUTPUT

as 
begin
	if (exists ( select * from myadmin MA where MA.email = @emailid and MA.passcode=@password))
	begin
		set	@done=1 
		print 'You are Signed in'
	end
	else 
	begin
		set @done=0
		print 'Sorry Incorrect Email or Password'
	end
end

declare @signin_succ int
exec adminsignin
@emailid= 'hammad@blah.com',
@password='hammadsucks1',
@done=@signin_succ OUTPUT

select @signin_succ as [SIGN IN SUCCESSFUL]

select * from myadmin



------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc adminSignup 
@email varchar(30),
@password varchar(20), 
@position varchar(30), 
@cnic varchar(13),
@done int OUTPUT
as
begin
	set @done=1
	if(@email not like '%@%')
	begin
		set @done=0
		print 'The email you provided has wrong syntax.'
	end
	if(exists (select email from myadmin where @email=email))
	begin
		set @done=0
		print 'The email you provided is already registered. Use some other email to register a new account or sign in using this email.'
	end
	if (exists (select * from myadmin where @cnic=cnic))
	begin
		set @done =0
	end
	if(@done=1)
	begin
		insert into myadmin values (@email,@position,@password,@cnic)--add record
	end
end

declare @dn int
exec adminSignup
@email='raima@gmail.com',
@password='raimaimran',
@position='manager',
@cnic='2346678900234',

@done=@dn OUTPUT

select @dn

select * from myadmin


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc ViewUser
@email varchar(30)
AS BEGIN
	select name, phoneno ,cnic
	from myuser
	where @email=email
End 

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc ViewAdmin 
@email varchar(30)
as begin
	select M.email, M.position, M.cnic
	from myadmin M
	where @email=email
end

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc addEvent 
@email varchar(30),
@eventid int,--pk
@name varchar(20),
@category varchar(20),
@eveDate date,
@linktoeventpage char(20), --website or emailid
@done int OUTPUT
as
begin
	set @done=1
	if(not exists (select * from myadmin where email=@email))
	begin
		set @done=0
		print 'You do not have the authority to add an event. Only admin can perform this action.'
	end
	if(@eventid = any ( select eventid from myevent))
	begin
		set @done=0
		print 'Event id has been used before'
	end
	if(@eveDate = any ( select eventDate from myevent where category = @category))
	begin
		set @done=0
		print 'Event date clash with another event of the same category'
	end
	if(@done=1)
	begin
		insert into myevent values (@eventid,@name,@category,@eveDate,@linktoeventpage);
	end
end

select* from myadmin
declare @mydone int;
exec addEvent
@email= 'amina@blah.com',
@eventid=3,--pk
@name='interface',
@category= 'education',
@eveDate ='2019-03-26',
@linktoeventpage ='abc.com', --website or emailid
@done=@mydone output
select @mydone
select* from myevent


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc addCase 
@email varchar(30),
@caseid int,--pk
@name varchar(20),
@category varchar(20),
@target_amount int,
@linktocustomer char(20), --website or emailid
@done int OUTPUT
as
begin
	set @done=1
	if(not exists (select * from myadmin where email=@email))
	begin
		set @done=0
		print 'You do not have the authority to add a case. Only admin can perform this action.'
	end
	if(@caseid = any ( select caseid from cases))
	begin
		set @done=0
		print 'Case id has been used before'
	end
	if(@done=1)
	begin
		insert into cases values (@caseid,@name,@category,@target_amount,@linktocustomer);
	end
end

select* from myadmin
declare @mydone int;
exec addCase
@email = 'amina@blah.com',
@caseid=4,
@name ='watch cells',
@category ='time saving',
@target_amount=1000,
@linktocustomer ='www.abc.com', --website or emailid
@done=@mydone output
select @mydone
select* from cases

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc removeEvent
@email varchar(30),
@eventid int ,
@done int OUTPUT
as begin
	if (not exists(select * from myadmin where @email= email))
	begin
		set @done =0 -- not possible to remove 
	end
	else if ( exists(select * from myevent where @eventid=eventid))
	begin
		set @done =1 --removed 
		delete from myevent where @eventid=eventid
		delete from volunteer where eventid=@eventid
	end
	else 
	begin
		set @done=0	
	end

end 

insert into myevent values(34,'idk','idk',null, 'abc.com')
insert into volunteer values('ali@blah.com', 34, 'abcdhg')


declare @dn int 
exec removeEvent
@email='hammad@blah.com',
@eventid = 34,
@done=@dn OUTPUT

select @dn

select * from myadmin


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc removeCase
@email varchar(30),
@caseid int ,
@done int OUTPUT
as begin
	if (not exists(select * from myadmin where @email= email))
	begin
		set @done =0 -- not possible to remove 
	end
	else if ( exists(select * from cases where @caseid=caseid))
	begin
		set @done =1 --removed 
		delete from cases where @caseid=caseid
		delete from donations where @caseid=caseid
	end
	else 
	begin
		set @done=0	
	end

end 


declare @dn int 
exec removeCase
@email='hammad@blah.com',
@caseid = 3,
@done=@dn OUTPUT

select @dn



------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc DisplayallCases --flagged case displayed to admin
as
begin
	select *
	from cases
end

exec DisplayallCases

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc DisplayflaggedCases --flagged case displayed to admin
as
begin
	select distinct C.caseid,C.name,C.category,C.target_amount,C.linktocustomer 
	from cases C join flaggedcase FC on FC.caseid=C.caseid
end

exec DisplayflaggedCases

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc DisplayallEvents
as
begin
	select * 
	from myevent
end

exec DisplayallEvents

insert into myevent values(3,'idk','idk','09-28-19','abc.com')

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc DisplayupcomingEvents
as
begin
	select * 
	from myevent
	where eventDate > getdate()
end

exec DisplayupcomingEvents


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc registerAsDonor 
@email varchar(30),
@accountno varchar(20),
@visitingaddress varchar(50),
@done int OUTPUT
as
begin
	set @done=1
	if(exists (select * from donor where donor.email=@email))
	begin 
		set @done=0
		print 'You are already registered as our donor'
	end
	if(@done=1)
	begin
		insert into donor values (@email,@accountno,@visitingaddress,'New bird');
		select * from donor join myuser on donor.email=myuser.email
	end
end


declare @mydone int;
exec registerAsDonor
@email= 'ag54@gmail.com',
@accountno =432, 
@visitingaddress ='51j-model town,hell.', 
@done=@mydone output
select @mydone

select * from donor


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



create proc registerAsVolunteer 
@email varchar(30),
@eventName varchar(20),
@position char(30),
@done int OUTPUT
as
begin
	declare @eventId int;
	select @eventId=eventid from myevent where @eventName=name 
	set @done=1
	if(exists (select * from volunteer where email=@email and eventid=@eventId))
	begin 
		set @done=0
		print 'You are already registered as our volunteer for this event'
	end
	if(@done=1)
	begin
		insert into volunteer values (@email,@eventId,@position);
		select * from volunteer join myuser on volunteer.email=myuser.email
	end
end

select * from myevent
select * from volunteer

declare @mydone int;
exec registerAsVolunteer
@email= 'ali@blah.com',
@eventName='funfairspecialpeople', 
@Position ='photographer', 
@done=@mydone output
select @mydone


select * from myevent

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc Donate 
@email varchar(30),
@caseName varchar(20),
@amount int,
@done int OUTPUT
as
begin
	declare @caseId int;
	declare @newAmount int;
	declare @goal int;
	select @caseId=caseid,@goal=target_amount from cases where name=@caseName
	select @newAmount+=amount_donated from donations where caseid=@caseid
	set @newAmount=@newAmount+@amount;
	set @done=1
	if(@newAmount>@goal)--check if email is of a registered donor
	begin 
		print 'Your donation exceeded our required amount for this case. Thankyou for donating '+@newAmount-@goal+' extra.'
		update donor set medals='Extra donor' where donor.email=@email -- new medal given to the one who donated extra in any case
	end
	if(not exists (select * from donor where email=@email))--check if email is of a registered donor
	begin 
		set @done=0
		print 'You are required to register as our donor in order to donate'
	end
	if(not exists (select * from cases where caseid=@caseId))--check if email is of a registered donor
	begin 
		set @done=0
		print 'The case you are trying to donate for does not exist'
	end
	if(@amount<5)
	begin 
		set @done=0
		print 'You are required to donate something worth'
	end
	if(@done=1)
	begin
		insert into donations values (@email,@caseId,@amount);
		select * from volunteer join myuser on volunteer.email=myuser.email
	end
end


select* from volunteer
select * from myevent
delete from donations where email= 'ali@blah.com'
declare @mydone int;
exec Donate
@email= 'ali@blah.com',
@caseName='abc', 
@amount=3000, 
@done=@mydone output
select @mydone

select* from donations
select * from myuser
select * from volunteer


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc donation_history
@email varchar(30)

as 
begin
	if (exists(select * from donor D1 where D1.email=@email))
	begin
		select DN.caseid, DN.amount_donated
		from donor D join donations DN on D.email=DN.email 
		where D.email=@email
	end
	else 
	begin
		print 'You have not donated'
	end

end

exec donation_history
@email='laraib@blah.com'

select * from donations

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc volunteer_history
@email varchar(30)

as 
begin
	if ( exists(select * from volunteer V where V.email=@email))
	begin
		select  ME.eventid , ME.name , ME.eventDate ,ME.category ,ME.linktoeventpage 
		from volunteer V1 join myevent ME on V1.eventid= ME.eventid join myuser MU on MU.email=V1.email
		where V1.email= @email
	end
	else
	begin
		print 'No record found'
	end
end 

exec volunteer_history
@email= 'ali@blah.com'

select * from volunteer


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc isAdmin
@email varchar(30),
@done int OUTPUT
as begin
	if ( exists(select * from myadmin where @email=email))
	begin
		set @done=1 ;
	end
	else 
	begin
		set @done =0;
	end
end


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc isUser
@email varchar(30),
@done int OUTPUT
as begin
	if ( exists(select * from myuser where @email=email))
	begin
		set @done=1 ;
	end
	else 
	begin
		set @done =0;
	end
end





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc reportCase
@email varchar(30),
@name varchar(20),
@done int OUTPUT
as begin
	declare @caseid int 
	select @caseid= caseid  
	from cases
	where @name=name

	if (exists(select * from flaggedcase where @email=email and @caseid=caseid))
	begin
		set @done =0;
	end
	else 
	begin
	insert into flaggedcase values(@email, @caseid)
	set @done =1
	end

end

select * from cases

declare @dn int 
exec reportCase
@email= 'ali@blah.com',
@name= 'abc',
@done = @dn OUTPUT

select @dn


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


alter proc requestvisit
@email varchar(30),
@name varchar(20),
@done int OUTPUT

as begin
	declare @eventid int 
	select @eventid=eventid
	from myevent
	where @name= name
	set @done =1

	if ( exists(select * from visitrequest where @email=email and @eventid=eventid))
	begin
		set @done =0
	end
	else 
	begin
		set @done =1
		insert into visitrequest values(@email, @eventid)
	end
end


declare @dn int 
exec requestvisit
@email= 'ali@blah.com',
@name= 'oldpeople',
@done= @dn OUTPUT

select @dn

select * from myuser
select * from visitrequest
delete from visitrequest where email='ali@blah.com'
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc deleteUser
@email varchar(30),
@useremail varchar(30),
@done int OUTPUT
as begin
	set @done =1
	if (not exists(select * from myadmin where @email= email))
	begin
		set @done =0
		print 'not admin'
	end
	if (not exists(select * from myuser where @useremail= email))
	begin
		set @done=0 
		print 'you dont exist'
	end
	if (@done =1)
	begin
		delete from myuser where @useremail=email
		delete from donations where @useremail=email
		delete from donor where @useremail=email
		delete from volunteer where @useremail=email
		delete from flaggedcase where @useremail=email
		delete from visitrequest where @useremail=email
	end
end

declare @dn int
exec deleteUser
@email= 'hammad@blah.com',
@useremail= 'laraib@blah.com',
@done=@dn OUTPUT

select @dn

select * from myuser



------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc displayallUsers
as begin

	select email
	from myuser
end

exec displayallUsers

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc viewallHealthcases
as begin
	select * 
	from cases
	where category='health'

end

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create proc viewallEducases
as begin
	select * 
	from cases
	where category='education'

end


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


create proc eventDetailsandVolunteers 
@eventName varchar(20)
as
begin
	declare @eventId int;
	select @eventId=eventid from myevent where CHARINDEX(@eventname,name,0)>=0 --check if this works even if a substring of event name is passed as parameter
	select * from volunteer left outer join myevent on volunteer.eventid=myevent.eventid where myevent.eventid=@eventId
end

select* from myevent
exec eventDetailsandVolunteers 
@eventName='old'


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

select * from donations

create proc [search event]
@eventname varchar(50)

as 
begin
	if ( exists(select * from myevent ME where CHARINDEX(@eventname , ME.name) >0 )) 
	begin 
		select *
		from myevent ME 
		where CHARINDEX(@eventname , ME.name) >0 
	end
	else 
	begin
		print 'No Match Found'
	end
end

exec [search event]
@eventname='fair'

select * from myevent

--sign in admin

--highest donor of each case

create proc [highest donor of case]
@caseid int 

as
begin 
		select top 1 MU.name, sum(DN.amount_donated)
		from cases C join donations DN on C.caseid=DN.caseid join donor D on D.email=DN.email join myuser MU on MU.email=D.email
		where C.caseid= @caseid
		group by MU.email, MU.name
		order by sum(DN.amount_donated) desc
end

exec [highest donor of case]
@caseid =7

select * from donations

--display case with all donors

create proc [display case and donors]
@caseid int 

as 
begin
	select C.caseid,C.name,MU.name
	from cases C join donations DN on DN.caseid= C.caseid join donor D on D.email=DN.email join myuser MU on MU.email=D.email
	where C.caseid= @caseid
end


exec [display case and donors]
@caseid =7


--case search(search bar)

create proc [search case]
@casename varchar(50)

as 
begin
	if ( exists(select * from cases C where CHARINDEX(@casename , C.name) >0 )) 
	begin 
		select *
		from cases C
		where CHARINDEX(@casename , C.name) >0 
	end
	else 
	begin
		print 'No Match Found'
	end
end

exec [search case]
@casename='health'

select * from cases



--------------
create proc donationsamount
@email varchar(30)
as
begin
select sum(amount_donated) as total_amount
from donations
where email=@email
--update 
end

exec donationsamount
@email= 'laraib@blah.com'
-------------
drop proc caseanddonors
create proc caseanddonors
@caseId int
as
begin
if ( exists(select * from cases c where c.caseid=@caseId))
begin
	declare @email  varchar(30);
	select *--@caseId=cases.caseid 
	from cases inner join donations on cases.caseid=donations.caseid where donations.caseid=@caseId
end
else 
	begin 
	print 'no such case'
end
end
exec caseanddonors
@caseId= 20
--------------------------------

drop proc ViewUser
-------------------------------------------

create proc removeEvent 
@email varchar(30),
@eventid int--pk
as
begin
	declare @done int
	set @done=1
	if(not exists (select * from myadmin where email=@email))
	begin
		set @done=0
		print 'You do not have the authority to add an event. Only admin can perform this action.'
	end
	if(@eventid in ( select eventid from myevent))
	begin
		set @done=0
	end
	if(@done=1)
	begin
		delete from myevent where eventid=@eventid
	end
end

select* from myadmin
declare @mydone int;
exec addEvent
@email= 'amina@blah.com',
@eventid=3,--pk
@name='interface',
@category= 'education',
@eveDate ='2019-03-26',
@linktoeventpage ='abc.com', --website or emailid
@done=@mydone output
select @mydone
select* from myevent

select* from donor
select * from myuser