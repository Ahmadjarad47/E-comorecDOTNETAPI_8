using E_commorec.core.InterFace.User;

namespace E_commorec.core.InterFace
{
    public interface IUnitOfWork
    {
        public IUsers users { get; }
        public IAdminControllingUsers ControllingUsers { get; }

        public IStudent Student { get; }
        public ITeacher Teacher { get; }
        public ICourse Course { get; }
        public ISubCourse SubCourse { get; }
        public INote note { get; }
        public ISupport support { get; }
    }
}
