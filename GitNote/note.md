# Git Global Setup

git config --gobal user.name "Full Name"
git config --gobal user.email " email"
git config --gobal color.ui auto
git config --gobal merge.conflictstyle diff3
git config --gobal core.editor "code --wait"

- Compare git reset and git rm --cash

  > Both can unstage a file and keep this file in working directory.
  > For git reset, file remains tracked by Git if it was tracked before. However, for git rm --cash, if the file was previously tracked by Git it will be removed from the repository in the next commit.

- The commands git checkout can be used to roll back to a certain commit hash

  > This command will move the HEAD to the specified commit, allowing you to view the state of the repository at that point. However, this puts you in a "detached HEAD" state, meaning you're not on any branch. If you want to make changes or create a new branch from that commit, you can do so after checking it out.

- Compare git log -p and git log
  > The -p flag stands for "patch," and it shows the changes made in each commit, line by line.
