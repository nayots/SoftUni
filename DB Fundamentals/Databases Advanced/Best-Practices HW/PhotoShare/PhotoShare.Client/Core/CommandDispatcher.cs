namespace PhotoShare.Client.Core
{
    using PhotoShare.Client.Core.Commands;
    using PhotoShare.Services;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            switch (commandName)
            {
                case "RegisterUser":
                    if (commandParameters.Count() != 4)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    RegisterUserCommand registerUser = new RegisterUserCommand(new UserService());
                    result = registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    if (commandParameters.Count() != 2)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    AddTownCommand addTown = new AddTownCommand(new TownService());
                    result = addTown.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    if (commandParameters.Count() != 3)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    ModifyUserCommand modifyUser = new ModifyUserCommand(new UserService(), new TownService());
                    result = modifyUser.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    if (commandParameters.Count() != 1)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    DeleteUserCommand deleteUser = new DeleteUserCommand(new UserService());
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    if (commandParameters.Count() != 1)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    AddTagCommand addTag = new AddTagCommand(new TagService());
                    result = addTag.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    if (commandParameters.Count() < 4)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand(new AlbumService(), new UserService(), new TagService());
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    if (commandParameters.Count() != 2)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    AddTagToCommand addTagTo = new AddTagToCommand(new TagService(), new AlbumService());
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    if (commandParameters.Count() != 2)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    MakeFriendsCommand makeFriends = new MakeFriendsCommand(new UserService());
                    result = makeFriends.Execute(commandParameters);
                    break;
                case "ListFriends":
                    if (commandParameters.Count() != 1)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    PrintFriendsListCommand printFriends = new PrintFriendsListCommand(new UserService());
                    result = printFriends.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    if (commandParameters.Count() != 3)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand(new UserService(), new AlbumService());
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    if (commandParameters.Count() != 3)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    UploadPictureCommand uploadPicture = new UploadPictureCommand(new AlbumService(), new PictureService());
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "Login":
                    if (commandParameters.Count() != 2)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    LoginCommand loginCommand = new LoginCommand(new AuthenticationService(), new UserService());
                    result = loginCommand.Execute(commandParameters);
                    break;
                case "Logout":
                    if (commandParameters.Count() > 0)
                    {
                        throw new InvalidOperationException($"Command {commandName} not valid!");
                    }
                    LogoutCommand logoutCommand = new LogoutCommand(new AuthenticationService(), new UserService());
                    result = logoutCommand.Execute();
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    throw new InvalidOperationException($"Command {commandName} not valid!");
                    break;
            }

            return result;
        }
    }
}
