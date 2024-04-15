using LibraryManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DataRepository
    {
        private DataContext context;
        private DataFill fill;

        public DataRepository(DataContext context, DataFill fill)
        {
            this.context = context;
            this.fill = fill;
        }

        public void FillStatic() => fill.Fill(context);

        #region Users
        public void AddUser(Users W)
        {
            context.user.Add(W);
        }

        public Users GetUser(string id)
        {
            foreach (var W in context.user)
            {
                if (W.Id == id)
                {
                    return W;
                }
            }
            throw new Exception("No user was found");
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return context.user;
        }

        public void DeleteUser(Users w)//jezeli jest 
        {
            foreach (var z in context.events)
            {
                if (z.w == w) throw new Exception("User has borrowed a book therefore he can not be deleted");
            }
            context.user.Remove(w);
        }

        public void DeleteUser(string _id)
        {
            Users tmp = GetUser(_id);

            foreach (var z in context.events)
            {
                if (z.w == tmp) throw new Exception("User has borrowed a book therefore he can not be deleted");
            }
            context.user.Remove(tmp);
        }

        #endregion

        #region Catalog
        private int CatalogCounter = 0;

        public int CatalogCounter1 { get => CatalogCounter; set => CatalogCounter = value; }

        public void AddCatalog(Catalog K)
        {
            context.catalogs.Add(CatalogCounter, K);
            CatalogCounter++;
        }

        public Catalog GetCatalog(int id)
        {
            return context.catalogs[id];
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return context.catalogs.Values;
        }

        public void DeleteCatalog(int id)
        {
            foreach (var O in context.states)
            {
                if (O.K1.Equals(context.catalogs[id])) throw new Exception("Object can not be deleted.It's used by StateDescription");
            }
            context.catalogs.Remove(id);
        }

        public void DeleteCatalog(Catalog K)
        {
            foreach (var O in context.states)
            {
                if (O.K1 == K) throw new Exception("Object can not be deleted.It's used by StateDescrition");
            }

            for (int id = 0; id < context.catalogs.Count; id++)
            {
                if (context.catalogs[id].Equals(K))
                {
                    context.catalogs.Remove(id);
                    return;
                }
            }
        }
        #endregion

        #region Event

        public void AddEvent(Event Z)
        {
            context.events.Add(Z);
        }

        public Event GetEvent(int id)
        {
            return context.events[id];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return context.events;
        }

        public void DeleteEvent(Event Z)
        {
            foreach (var zz in context.events)
            {
                if (Z.Equals(zz))
                {
                    context.events.Remove(Z);
                    return;
                }
            }
            throw new Exception("Such event does not exist");
        }

        #endregion

        #region StateDescription

        public void AddStateDescription(StateDescription O)
        {
            context.states.Add(O);
        }

        public StateDescription GetStateDescription(int id)
        {
            return context.states[id];
        }

        public IEnumerable<StateDescription> GetAllStateDescriptions()
        {
            return context.states;
        }

        public void DeleteStateDescription(StateDescription O)
        {
            foreach (var z in context.events)
            {
                if (z.o.Equals(O))
                {
                    throw new Exception("StateDescription is used");
                }
            }
            context.states.Remove(O);
        }

        public void DeleteStateDescription(int id)
        {
            StateDescription O = GetStateDescription(id);
            foreach (var z in context.events)
            {
                if (z.o.Equals(O))
                {
                    throw new Exception("StateDescription is used");
                }
            }
            context.states.Remove(O);
        }

        #endregion
    }
}
