using Content.Server.Atmos.EntitySystems;
using Content.Server.Radiation.Systems;
using Content.Server.Radiation.Components;
using Content.Shared.Atmos;
using Robust.Shared.Map;
using Robust.Shared.GameObjects;
using Robust.Shared.Timing;

namespace Content.Server.Atmos;

/// <summary>
/// Applies radiation to nearby entities when tritium exists in nearby active atmos tiles.
/// </summary>

[UpdateAfter(typeof(AtmosphereSystem))]
public sealed class TritiumRadiationSystem : EntitySystem
{
	[Dependency] private readonly AtmosphereSystem _atmos = default!;
    [Dependency] private readonly RadiationSystem _radiation = default!;
    [Dependency] private readonly IEntityManager _entMan = default!;
    [Dependency] private readonly IGameTiming _timing = default!;

	private TimeSpan _nextUpdate;
	private const float UpdateInterval = 2.0f; // seconds
	private readonly Dictionary<EntityUid, RadiationSourceComponent> _virtualSources = new();

	// accumulate time until we exceed our interval, then run the mainloop
	// robust against tickrate variation because we're counting seconds here, not frames
	public override void Update(float frameTime)
	{
		if (_timing.TotalTime < _nextUpdate) return;

		_nextUpdate = _timing.TotalTime + TimeSpan.FromSeconds(UpdateInterval);
		MainLoop();
	}

	private void MainLoop() {
		// TODO: implement main loop thing

		// foreach (var grid in getallgrids())
			// var activetiles = getallactivetiles();
			// var tritium = activeTiles;
			// var tritiumTiles = activeTiles
				// .Where(tile => getMoles(tile, trit) >= Atmospherics.TritiumRadiationThreshold)
				// .ToList();
			// var clusters = ClusterTritiumTiles(tritiumTiles);
			// foreach (var cluster in clusters)
				// var rads = cluster.RadsPerSecond;
				// ApplyClusterRads(cluster);
	}
	

	private List<TritiumCluster> ClusterTritiumTiles(List<EntityCoordinates> tiles) {
		// TODO: implement helper that clusters tritium tiles together

		// var visited = new HashSet<EntityCoordinates>();
		// var clusters = new List<TritiumCluster>();
		// foreach (var tile in tiles)
			// if (visited.Contains(tile)) continue;
			// var cluster = new TritiumCluster();
			// var toVisit = new Queue<EntityCoordinates>();
			// toVisit.Enqueue(tile);

			// while (toVisit.Count > 0)
				// var current = toVisit.Dequeue();
				// if (visited.Contains(current)) continue;
				// visited.Add(current);
				// cluster.Tiles.Add(current);

				// foreach (var neighbor in tiles)
					// if (!visited.Contains(neighbor)) && (neighbor.Position - current.Position).Length <= Atmospherics.TritiumClusterRadius))
						// toVisit.Enqueue(neighbor);
			// clusters.Add(cluster);
				
		// return cluster;
	}

	private void ApplyClusterRads(TritiumCluster cluster) {
		// TODO: implement application of cluster rads

		// EntityUid uid = GetOrCreateVirtualSource();
		// var source = EnsureComp<RadiationSourceComponent>;
		// source.Enabled = true;
		// source.RadsPerSecond = cluster.RadsPerSecond;
		// coordinates = cluster.Tiles[0];
	}

	// i shouldn't have to explain this one
	private float CalculateRads(float moles) {
		return mols * Atmospherics.TritiumRadsPerMol;
	}

	private sealed class TritiumCluster
	{
		public List<EntityCoordinates> Tiles = new();
		public float RadsPerSecond;
	}
}