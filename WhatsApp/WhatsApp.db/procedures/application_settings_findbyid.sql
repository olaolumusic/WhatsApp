create procedure application_settings_findbyId
(@id int
)
as 
select * from application_settings
where Id = @id
