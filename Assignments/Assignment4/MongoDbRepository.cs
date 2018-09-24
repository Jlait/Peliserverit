using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using Assignment4;

namespace assignment4
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
        }

        public async Task<Player> Create(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player[]> GetAllPlayers()
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }

        public Task<Player> GetPlayer(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstAsync();
        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            var filter = Builders<Player>.Filter.Eq("_id", id);
            Player newplayer = new Player();
            newplayer.Score = player.Score;
            await _collection.ReplaceOneAsync(filter, newplayer);
            return newplayer;
        }

        public Task<Player> Delete(Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq("_id", playerId);
            _collection.DeleteOneAsync(filter);
            return null;
        }

        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            var filter = Builders<Player>.Filter.Eq("_id", playerId);
            var update = Builders<Player>.Update.Push("Items", item);
            await _collection.FindOneAndUpdateAsync(filter, update);
            return item;
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemid)
        {
            Player player = await this.GetPlayer(playerId);
            Item[] itemList = player.Items.ToArray();
            foreach (var item in itemList)
            {
                if (item.ItemID == itemid)
                {
                    return item;
                }
            }
            return (Item)null;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            Player player = await this.GetPlayer(playerId);
            return player.Items.ToArray();
        }

        public async Task<Item> Modify(Guid playerId, Guid itemid, ModifiedItem item)
        {
            Player player = await this.GetPlayer(playerId);

            Item newItem = new Item();

            newItem.Level = item.Level;
            newItem.ItemType = item.ItemType;
            Item[] itemList = player.Items.ToArray();
            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].ItemID == itemid)
                {
                    newItem.ItemID = itemList[i].ItemID;
                    newItem.CreationDate = itemList[i].CreationDate;
                    itemList[i] = newItem;
                }
            }
            player.Items = itemList.ToList();

            await _collection.ReplaceOneAsync(Builders<Player>
            .Filter.Eq("_id", playerId), player);
            return newItem;
        }

        public async Task<Item> DeleteItem(Guid playerId, Guid itemid)
        {
            Player player = await this.GetPlayer(playerId);
            List<Item> itemList = player.Items;
            Item temp = null;

            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].ItemID == itemid)
                {
                    temp = itemList[i];
                    itemList.Remove(itemList[i]);
                }
            }
            player.Items = itemList;
            await _collection.ReplaceOneAsync(Builders<Player>
            .Filter.Eq("_id", playerId), player);
            return temp;
        }
    }
}