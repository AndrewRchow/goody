-- Select All
EXECUTE EditorContent_GetAll

-- Insert
DECLARE @Id INT;
EXECUTE EditorContent_Insert 'Test Title 3', 'Test Description 3', @Id OUTPUT;
SELECT @id
EXECUTE EditorContent_SelectById @Id;

-- Update
DECLARE 
	@Id INT = 8,
	@Title NVARCHAR(25) = 'Update Title 3',
	@Description NVARCHAR(250) = 'Updated Description 3'
EXECUTE EditorContent_Update @Id, @Title, @Description
SELECT @id
EXECUTE EditorContent_SelectById @Id;

-- Delete
EXECUTE EditorContent_DeleteById 1
