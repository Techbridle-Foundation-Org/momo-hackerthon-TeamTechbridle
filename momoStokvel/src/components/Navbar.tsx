const Navbar = () => {
  return (
    <header className="bg-white shadow p-4 flex justify-between items-center">
      <h1 className="text-xl font-semibold">Welcome Back 👋</h1>
      <div className="flex items-center gap-4">
        <span className="text-gray-700">John Doe</span>
        <img src="https://via.placeholder.com/40" alt="avatar" className="rounded-full w-10 h-10"/>
      </div>
    </header>
  );
};

export default Navbar;
