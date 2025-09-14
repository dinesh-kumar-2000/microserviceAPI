`-- Create New User
CREATE PROCEDURE [dbo].[sp_CreateUser]
    @UserName NVARCHAR(256),
    @Email NVARCHAR(256),
    @PasswordHash NVARCHAR(512)
AS
BEGIN
    INSERT INTO [dbo].[Users] (UserName, Email, PasswordHash)
    VALUES (@UserName, @Email, @PasswordHash);
END

-- Find User By Email
CREATE PROCEDURE [dbo].[sp_GetUserByEmail]
    @Email NVARCHAR(256)
AS
BEGIN
    SELECT * FROM [dbo].[Users] WHERE Email = @Email;
END

-- Update PasswordHash (used in reset/forgot, or change password)
CREATE PROCEDURE [dbo].[sp_UpdateUserPassword]
    @UserId UNIQUEIDENTIFIER,
    @NewPasswordHash NVARCHAR(512)
AS
BEGIN
    UPDATE [dbo].[Users]
    SET PasswordHash = @NewPasswordHash, UpdatedAt = SYSDATETIMEOFFSET()
    WHERE Id = @UserId;
END
-- Create Role
CREATE PROCEDURE [dbo].[sp_CreateRole]
    @Name NVARCHAR(128),
    @Description NVARCHAR(256) = NULL
AS
BEGIN
    INSERT INTO [dbo].[Roles] (Name, Description)
    VALUES (@Name, @Description);
END

-- Get All Roles
CREATE PROCEDURE [dbo].[sp_GetRoles]
AS
BEGIN
    SELECT Id, Name, Description FROM [dbo].[Roles];
END

-- Assign Role to User
CREATE PROCEDURE [dbo].[sp_AssignRoleToUser]
    @UserId UNIQUEIDENTIFIER,
    @RoleId UNIQUEIDENTIFIER
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[UserRoles] WHERE UserId = @UserId AND RoleId = @RoleId)
    BEGIN
        INSERT INTO [dbo].[UserRoles] (UserId, RoleId)
        VALUES (@UserId, @RoleId);
    END
END

-- Remove Role from User
CREATE PROCEDURE [dbo].[sp_RemoveRoleFromUser]
    @UserId UNIQUEIDENTIFIER,
    @RoleId UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[UserRoles] WHERE UserId = @UserId AND RoleId = @RoleId;
END

-- Get Roles For User
CREATE PROCEDURE [dbo].[sp_GetRolesForUser]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT R.Id, R.Name
    FROM [dbo].[Roles] R
    INNER JOIN [dbo].[UserRoles] UR ON R.Id = UR.RoleId
    WHERE UR.UserId = @UserId;
END

-- Create Refresh Token
CREATE PROCEDURE [dbo].[sp_CreateRefreshToken]
    @UserId UNIQUEIDENTIFIER,
    @Token NVARCHAR(512),
    @ExpiresAt DATETIMEOFFSET
AS
BEGIN
    INSERT INTO [dbo].[RefreshTokens] (UserId, Token, ExpiresAt)
    VALUES (@UserId, @Token, @ExpiresAt);
END

-- Get Valid Refresh Token
CREATE PROCEDURE [dbo].[sp_GetRefreshToken]
    @Token NVARCHAR(512)
AS
BEGIN
    SELECT * FROM [dbo].[RefreshTokens]
    WHERE Token = @Token AND RevokedAt IS NULL AND ExpiresAt > SYSDATETIMEOFFSET();
END

-- Revoke Refresh Token
CREATE PROCEDURE [dbo].[sp_RevokeRefreshToken]
    @Token NVARCHAR(512)
AS
BEGIN
    UPDATE [dbo].[RefreshTokens]
    SET RevokedAt = SYSDATETIMEOFFSET()
    WHERE Token = @Token;
END


-- Add User Claim
CREATE PROCEDURE [dbo].[sp_AddUserClaim]
    @UserId UNIQUEIDENTIFIER,
    @ClaimType NVARCHAR(256),
    @ClaimValue NVARCHAR(512)
AS
BEGIN
    INSERT INTO [dbo].[UserClaims] (UserId, ClaimType, ClaimValue)
    VALUES (@UserId, @ClaimType, @ClaimValue);
END

-- Get User Claims
CREATE PROCEDURE [dbo].[sp_GetUserClaims]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT ClaimType, ClaimValue
    FROM [dbo].[UserClaims]
    WHERE UserId = @UserId;
END


-- Insert Audit Log
CREATE PROCEDURE [dbo].[sp_InsertAuditLog]
    @UserId UNIQUEIDENTIFIER = NULL,
    @EventType NVARCHAR(128),
    @EventData NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO [dbo].[AuditLogs] (UserId, EventType, EventData)
    VALUES (@UserId, @EventType, @EventData);
END

-- Get Logs For User
CREATE PROCEDURE [dbo].[sp_GetAuditLogsForUser]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT * FROM [dbo].[AuditLogs]
    WHERE UserId = @UserId
    ORDER BY OccurredAt DESC;
END

-- Assign Role to User
CREATE PROCEDURE [dbo].[sp_AssignRoleToUser]
    @UserId UNIQUEIDENTIFIER,
    @RoleId UNIQUEIDENTIFIER
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[UserRoles] WHERE UserId = @UserId AND RoleId = @RoleId)
    BEGIN
        INSERT INTO [dbo].[UserRoles] (UserId, RoleId)
        VALUES (@UserId, @RoleId);
    END
END
CREATE PROCEDURE [dbo].[sp_GetUserById]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        Id,
        UserName,
        Email,
        PasswordHash,
        SecurityStamp,
        IsEmailConfirmed,
        IsLockedOut,
        LockoutEnd,
        CreatedAt,
        UpdatedAt,
        TwoFactorEnabled,
        AuthenticatorKey
    FROM [dbo].[Users]
    WHERE Id = @UserId;
END
