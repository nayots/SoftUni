BACKUP DATABASE SoftUni
TO DISK = 'D:\softuni-backup.bak'
WITH FORMAT, INIT,
	MEDIANAME = 'D_SQLBackups',
	NAME = 'Full backup of SoftUni DB';