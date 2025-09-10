import { BrowserRouter, Routes, Route } from "react-router-dom";


const Sidebar = () => {
  return (
    <div className="w-64 bg-indigo-600 text-white flex flex-col">
      <h2 className="text-2xl font-bold p-4">MoMo Stockvel</h2>
      <nav className="flex-1">
        <ul>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/dashboard">Dashboard</Link></li>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/mystockvels">My Stockvels</Link></li>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/investments">Investments</Link></li>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/payments">Payments</Link></li>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/reports">Reports</Link></li>
          <li><Link className="block p-3 hover:bg-indigo-500" to="/settings">Settings</Link></li>
        </ul>
      </nav>
    </div>
  );
};

export default Sidebar;
 